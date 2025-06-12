'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { TipoStatusBiuGridAdapter } from '@/app/GerAdv_TS/TipoStatusBiu/Adapter/TipoStatusBiuGridAdapter';
import TipoStatusBiuGridContainer from '@/app/GerAdv_TS/TipoStatusBiu/Components/TipoStatusBiuGridContainer';
const TipoStatusBiuPage: React.FC = () => {
  const TipoStatusBiuGrid = new TipoStatusBiuGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Staus  Usuários' />
    <TipoStatusBiuGridContainer grid={TipoStatusBiuGrid} />
  </PageLayout>
);
};
export default TipoStatusBiuPage;