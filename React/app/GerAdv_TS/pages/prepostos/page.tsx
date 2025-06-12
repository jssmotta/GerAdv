'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { PrepostosGridAdapter } from '@/app/GerAdv_TS/Prepostos/Adapter/PrepostosGridAdapter';
import PrepostosGridContainer from '@/app/GerAdv_TS/Prepostos/Components/PrepostosGridContainer';
const PrepostosPage: React.FC = () => {
  const PrepostosGrid = new PrepostosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Prepostos' />
    <PrepostosGridContainer grid={PrepostosGrid} />
  </PageLayout>
);
};
export default PrepostosPage;