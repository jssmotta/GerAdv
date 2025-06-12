'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { GUTAtividadesMatrizGridAdapter } from '@/app/GerAdv_TS/GUTAtividadesMatriz/Adapter/GUTAtividadesMatrizGridAdapter';
import GUTAtividadesMatrizGridContainer from '@/app/GerAdv_TS/GUTAtividadesMatriz/Components/GUTAtividadesMatrizGridContainer';
const GUTAtividadesMatrizPage: React.FC = () => {
  const GUTAtividadesMatrizGrid = new GUTAtividadesMatrizGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='G U T Atividades Matriz' />
    <GUTAtividadesMatrizGridContainer grid={GUTAtividadesMatrizGrid} />
  </PageLayout>
);
};
export default GUTAtividadesMatrizPage;