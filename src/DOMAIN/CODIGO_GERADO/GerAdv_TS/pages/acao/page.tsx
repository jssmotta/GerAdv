'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AcaoGridAdapter } from '@/app/GerAdv_TS/Acao/Adapter/AcaoGridAdapter';
import AcaoGridContainer from '@/app/GerAdv_TS/Acao/Components/AcaoGridContainer';
const AcaoPage: React.FC = () => {
  const AcaoGrid = new AcaoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Acao' />
    <AcaoGridContainer grid={AcaoGrid} />
  </PageLayout>
);
};
export default AcaoPage;