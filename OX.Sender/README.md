# OX.Mailer 1.0.4



Example

    using OX.Sender;
    using OX.Sender.Entities;


    public Class User
    {        
        private MailConfiguration mailConfiguration = new();
        public void Save(User)
        {    
             //Code  to save user
            

             //code to send email
            mailConfiguration.FromAddress = _config["FromAddress"];
            mailConfiguration.Password = _config["Password"];
            mailConfiguration.Subject = _config["Subject"];
            mailConfiguration.Host = _config["host"];
            mailConfiguration.ToAddress = email;
            mailConfiguration.Template = _config["templatePath"];
            string imagePath = path;

            Mail mail = new Mail(mailConfiguration);

            mail.Send();

            //or can replace imagepath, email and link data in template
            mail.Send(imagePath, email, link);

        }

    }

    //Template example
    <p>Hi {femail}!</p>
    <p>Click link below to validate email address</p>
    <a href="{flink}" class="btn btn-primary">Validate email</a>
    </center>