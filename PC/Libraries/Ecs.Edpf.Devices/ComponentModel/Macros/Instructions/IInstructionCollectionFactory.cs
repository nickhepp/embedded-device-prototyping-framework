namespace Ecs.Edpf.Devices.ComponentModel.Macros.Instructions
{
    public interface IInstructionCollectionFactory
    {
        InstructionCollection ParseDeviceTextMacroInitArgs(InstructionCollectionInitArgs initArgs);
    }
}