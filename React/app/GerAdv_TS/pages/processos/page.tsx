'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ProcessosGridAdapter } from '@/app/GerAdv_TS/Processos/Adapter/ProcessosGridAdapter';
import ProcessosGridContainer from '@/app/GerAdv_TS/Processos/Components/ProcessosGridContainer';
const ProcessosPage: React.FC = () => {
  const ProcessosGrid = new ProcessosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Processos' />
    <ProcessosGridContainer grid={ProcessosGrid} />
  </PageLayout>
);
};
export default ProcessosPage;