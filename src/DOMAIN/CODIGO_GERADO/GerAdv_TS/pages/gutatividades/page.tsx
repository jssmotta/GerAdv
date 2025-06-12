'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { GUTAtividadesGridAdapter } from '@/app/GerAdv_TS/GUTAtividades/Adapter/GUTAtividadesGridAdapter';
import GUTAtividadesGridContainer from '@/app/GerAdv_TS/GUTAtividades/Components/GUTAtividadesGridContainer';
const GUTAtividadesPage: React.FC = () => {
  const GUTAtividadesGrid = new GUTAtividadesGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='G U T Atividades' />
    <GUTAtividadesGridContainer grid={GUTAtividadesGrid} />
  </PageLayout>
);
};
export default GUTAtividadesPage;