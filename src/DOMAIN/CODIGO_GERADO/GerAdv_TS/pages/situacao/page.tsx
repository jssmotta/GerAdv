'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { SituacaoGridAdapter } from '@/app/GerAdv_TS/Situacao/Adapter/SituacaoGridAdapter';
import SituacaoGridContainer from '@/app/GerAdv_TS/Situacao/Components/SituacaoGridContainer';
const SituacaoPage: React.FC = () => {
  const SituacaoGrid = new SituacaoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Situação' />
    <SituacaoGridContainer grid={SituacaoGrid} />
  </PageLayout>
);
};
export default SituacaoPage;