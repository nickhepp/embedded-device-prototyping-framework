using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel.Macros.Instructions
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

    }
}
