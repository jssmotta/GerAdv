'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ProResumosGridAdapter } from '@/app/GerAdv_TS/ProResumos/Adapter/ProResumosGridAdapter';
import ProResumosGridContainer from '@/app/GerAdv_TS/ProResumos/Components/ProResumosGridContainer';
const ProResumosPage: React.FC = () => {
  const ProResumosGrid = new ProResumosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Pro Resumos' />
    <ProResumosGridContainer grid={ProResumosGrid} />
  </PageLayout>
);
};
export default ProResumosPage;