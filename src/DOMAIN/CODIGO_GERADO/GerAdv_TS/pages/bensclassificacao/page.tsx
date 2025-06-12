'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { BensClassificacaoGridAdapter } from '@/app/GerAdv_TS/BensClassificacao/Adapter/BensClassificacaoGridAdapter';
import BensClassificacaoGridContainer from '@/app/GerAdv_TS/BensClassificacao/Components/BensClassificacaoGridContainer';
const BensClassificacaoPage: React.FC = () => {
  const BensClassificacaoGrid = new BensClassificacaoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Bens Classificacao' />
    <BensClassificacaoGridContainer grid={BensClassificacaoGrid} />
  </PageLayout>
);
};
export default BensClassificacaoPage;