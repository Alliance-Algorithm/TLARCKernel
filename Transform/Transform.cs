namespace TlarcKernel.Transform;

class Transform : Component
{
    public Vector3d Position;
    public Quaterniond Rotation;
    public Vector3d Velocity;
    // public Vector3d LocalPosition { get => Parent == null ? Position : Position - Parent.Position; }
    // public Quaterniond LocalRotation { get => Parent == null ? Rotation : Rotation * Parent.Rotation.Conjugate(); }

    // public Transform Parent;
}