public interface IPausable 
{
        bool IsPaused { get; set; }
        void OnPause();
        void OnResume();
}
