namespace web_file_uploader.Models
{
    public class FileUploadModel
    {
        // Add properties needed for the external handler to process the upload properly.
        // Properties needed are:
        // File name
        public string FileName { get; set; }
        // File type (extension, e.g. .pdf, .txt)
        // TODO: Add validation for accepted file types. Not sure if that's done here, or in the controller, adding this as a reminder.
        public string FileType { get; set; }
        // File data (which we will store in bytes because the handler accepts the data in bytes, represents the file in binary)
        public byte[] FileData { get; set; }
        // Date the file was received on.
        // TODO: The user will be able to choose a received on date if the file was received on a prior date.
        // Not sure if this is handled here or in the views. Will update at a later time when necessary. This is a reminder.
        public DateTime DateReceived { get; set; }
        // File size. I chose to go with the int data type because I'm not expecting to have users upload files larger than 2 gigabytes.
        // The long data type is used if you are expecting large files. Declaring the int data type will possibly speed up the application.
        // Need to add validation to cap at 2 gigabytes or the user will receive an error message indicating the file is too large.
        // Data type long: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807 bytes. 64-bit signed integer. Files up to 8 exabytes in size.
        // Data type int: -2,147,483,648 to 2,147,483,647 bytes. 32-bit signed integer. Files up to 2 gigabytes in size.

    }
}
