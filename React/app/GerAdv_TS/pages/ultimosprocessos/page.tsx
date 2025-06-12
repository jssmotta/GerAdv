'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { UltimosProcessosGridAdapter } from '@/app/GerAdv_TS/UltimosProcessos/Adapter/UltimosProcessosGridAdapter';
import UltimosProcessosGridContainer from '@/app/GerAdv_TS/UltimosProcessos/Components/UltimosProcessosGridContainer';
const UltimosProcessosPage: React.FC = () => {
  const UltimosProcessosGrid = new UltimosProcessosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Ultimos Processos' />
    <UltimosProcessosGridContainer grid={UltimosProcessosGrid} />
  </PageLayout>
);
};
export default UltimosProcessosPage;