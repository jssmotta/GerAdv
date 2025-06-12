'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ProcessosParadosGridAdapter } from '@/app/GerAdv_TS/ProcessosParados/Adapter/ProcessosParadosGridAdapter';
import ProcessosParadosGridContainer from '@/app/GerAdv_TS/ProcessosParados/Components/ProcessosParadosGridContainer';
const ProcessosParadosPage: React.FC = () => {
  const ProcessosParadosGrid = new ProcessosParadosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Processos Parados' />
    <ProcessosParadosGridContainer grid={ProcessosParadosGrid} />
  </PageLayout>
);
};
export default ProcessosParadosPage;