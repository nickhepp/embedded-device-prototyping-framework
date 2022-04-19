using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public class CommentInstruction : Instruction
    {

        public const string CommentPrefix = "#";

        public override InstructionType InstructionType => InstructionType.Comment;

        public string CommentText { get; set; }

        public CommentInstruction(string commentText)
        {
            CommentText = commentText;
        }

        public override string GetDeviceText()
        {
            return null;
        }

        public override Instruction Copy()
        {
            CommentInstruction instruction = new CommentInstruction(this.CommentText);
            return instruction;
        }
    }
}
