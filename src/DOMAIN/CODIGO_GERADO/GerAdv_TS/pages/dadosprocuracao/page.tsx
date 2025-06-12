'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { DadosProcuracaoGridAdapter } from '@/app/GerAdv_TS/DadosProcuracao/Adapter/DadosProcuracaoGridAdapter';
import DadosProcuracaoGridContainer from '@/app/GerAdv_TS/DadosProcuracao/Components/DadosProcuracaoGridContainer';
const DadosProcuracaoPage: React.FC = () => {
  const DadosProcuracaoGrid = new DadosProcuracaoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Dados Procuracao' />
    <DadosProcuracaoGridContainer grid={DadosProcuracaoGrid} />
  </PageLayout>
);
};
export default DadosProcuracaoPage;