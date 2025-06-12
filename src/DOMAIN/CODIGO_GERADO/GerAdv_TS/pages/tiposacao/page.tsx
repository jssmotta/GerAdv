'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { TiposAcaoGridAdapter } from '@/app/GerAdv_TS/TiposAcao/Adapter/TiposAcaoGridAdapter';
import TiposAcaoGridContainer from '@/app/GerAdv_TS/TiposAcao/Components/TiposAcaoGridContainer';
const TiposAcaoPage: React.FC = () => {
  const TiposAcaoGrid = new TiposAcaoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Tipos Acao' />
    <TiposAcaoGridContainer grid={TiposAcaoGrid} />
  </PageLayout>
);
};
export default TiposAcaoPage;