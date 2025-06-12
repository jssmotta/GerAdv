'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { HistoricoGridAdapter } from '@/app/GerAdv_TS/Historico/Adapter/HistoricoGridAdapter';
import HistoricoGridContainer from '@/app/GerAdv_TS/Historico/Components/HistoricoGridContainer';
const HistoricoPage: React.FC = () => {
  const HistoricoGrid = new HistoricoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Historico' />
    <HistoricoGridContainer grid={HistoricoGrid} />
  </PageLayout>
);
};
export default HistoricoPage;