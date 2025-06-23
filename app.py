from flask import Flask, render_template, request, redirect, url_for, session
import smtplib
from email.message import EmailMessage
import imaplib
import email
from email.header import decode_header

app = Flask(__name__)
app.secret_key = "ftljvcblziwbftnq"

def send_email(from_email, app_password, to_email, subject, body):
    msg = EmailMessage()
    msg["Subject"] = subject
    msg["From"] = from_email
    msg["To"] = to_email
    msg.set_content(body)
    try:
        with smtplib.SMTP_SSL("smtp.gmail.com", 465) as smtp:
            smtp.login(from_email, app_password)
            smtp.send_message(msg)
        return True, "Email sent successfully!"
    except Exception as e:
        return False, str(e)

def fetch_emails(email_address, app_password, num=10):
    imap_server = "imap.gmail.com"
    emails = []
    try:
        mail = imaplib.IMAP4_SSL(imap_server)
        mail.login(email_address, app_password)
        mail.select("inbox")
        status, messages = mail.uid('search', None, 'ALL')
        email_uids = messages[0].split()
        for uid in email_uids[-num:][::-1]:
            status, data = mail.uid("fetch", uid, "(RFC822)")
            msg = email.message_from_bytes(data[0][1])
            subject, encoding = decode_header(msg["Subject"])[0]
            if isinstance(subject, bytes):
                subject = subject.decode(encoding if encoding else "utf-8")
            from_ = msg["From"]
            date = msg["Date"]
            body = ""
            if msg.is_multipart():
                for part in msg.walk():
                    content_type = part.get_content_type()
                    if content_type == "text/plain" and not part.get("Content-Disposition"):
                        body += part.get_payload(decode=True).decode(errors="ignore")
            else:
                content_type = msg.get_content_type()
                if content_type == "text/plain":
                    body = msg.get_payload(decode=True).decode(errors="ignore")
                elif content_type == "text/html":
                    body = msg.get_payload(decode=True).decode(errors="ignore")
            emails.append({"subject": subject, "from": from_, "date": date, "body": body, "uid": uid.decode()})
        mail.logout()
    except Exception as e:
        emails.append({"subject": "Error", "from": "", "date": "", "body": str(e)})
    return emails

@app.route("/", methods=["GET", "POST"])
def index():
    if request.method == "POST":
        from_email = request.form["from_email"]
        app_password = request.form["app_password"]
        to_email = request.form["to_email"]
        subject = request.form["subject"]
        body = request.form["body"]
        success, message = send_email(from_email, app_password, to_email, subject, body)
        return render_template("index.html", message=message, success=success)
    return render_template("index.html")

@app.route("/inbox", methods=["GET", "POST"])
def inbox():
    if request.method == "POST":
        from_email = request.form.get("from_email")
        app_password = request.form.get("app_password")
        session["from_email"] = from_email
        session["app_password"] = app_password
    else:
        from_email = session.get("from_email")
        app_password = session.get("app_password")

    if not from_email or not app_password:
        return redirect("/")

    emails = fetch_emails(from_email, app_password)
    return render_template("inbox.html", emails=emails)

@app.route("/email/<uid>")
def email_detail(uid):
    from_email = session.get("from_email")
    app_password = session.get("app_password")

    if not from_email or not app_password:
        return redirect("/")

    try:
        mail = imaplib.IMAP4_SSL("imap.gmail.com")
        mail.login(from_email, app_password)
        mail.select("inbox")
        result, data = mail.uid("fetch", uid.encode(), "(RFC822)")
        raw_email = data[0][1]
        msg = email.message_from_bytes(raw_email)

        subject, encoding = decode_header(msg["Subject"])[0]
        if isinstance(subject, bytes):
            subject = subject.decode(encoding if encoding else "utf-8")

        from_ = msg["From"]
        date = msg["Date"]
        body = ""
        if msg.is_multipart():
            for part in msg.walk():
                if part.get_content_type() == "text/html" and not part.get("Content-Disposition"):
                    body += part.get_payload(decode=True).decode(errors="ignore")
                    break
                elif part.get_content_type() == "text/plain" and not part.get("Content-Disposition"):
                    body += part.get_payload(decode=True).decode(errors="ignore")
        else:
            content_type = msg.get_content_type()
            if content_type == "text/html":
                body = msg.get_payload(decode=True).decode(errors="ignore")
            elif content_type == "text/plain":
                body = msg.get_payload(decode=True).decode(errors="ignore")

        email_obj = {
            "subject": subject,
            "from": from_,
            "date": date,
            "body": body,
            "uid": uid
        }

        return render_template("email_detail.html", mail=email_obj, is_html=True)

    except Exception as e:
        return f"Lỗi khi xem chi tiết email: {str(e)}"

if __name__ == "__main__":
    app.run(debug=True)
