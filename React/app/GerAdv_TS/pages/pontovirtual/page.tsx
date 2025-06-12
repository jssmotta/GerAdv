'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { PontoVirtualGridAdapter } from '@/app/GerAdv_TS/PontoVirtual/Adapter/PontoVirtualGridAdapter';
import PontoVirtualGridContainer from '@/app/GerAdv_TS/PontoVirtual/Components/PontoVirtualGridContainer';
const PontoVirtualPage: React.FC = () => {
  const PontoVirtualGrid = new PontoVirtualGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Ponto Virtual' />
    <PontoVirtualGridContainer grid={PontoVirtualGrid} />
  </PageLayout>
);
};
export default PontoVirtualPage;