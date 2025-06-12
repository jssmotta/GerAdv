'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { PontoVirtualAcessosGridAdapter } from '@/app/GerAdv_TS/PontoVirtualAcessos/Adapter/PontoVirtualAcessosGridAdapter';
import PontoVirtualAcessosGridContainer from '@/app/GerAdv_TS/PontoVirtualAcessos/Components/PontoVirtualAcessosGridContainer';
const PontoVirtualAcessosPage: React.FC = () => {
  const PontoVirtualAcessosGrid = new PontoVirtualAcessosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Ponto Virtual Acessos' />
    <PontoVirtualAcessosGridContainer grid={PontoVirtualAcessosGrid} />
  </PageLayout>
);
};
export default PontoVirtualAcessosPage;