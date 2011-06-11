namespace Epiworx.Data
{
    public interface INoteDataFactory
    {
        NoteData Fetch(NoteDataCriteria criteria);
        NoteData[] FetchInfoList(NoteDataCriteria criteria);
        NoteData Update(NoteData data);
        NoteData Insert(NoteData data);
        void Delete(NoteDataCriteria criteria);
    }
}
