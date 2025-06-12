'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AtividadesGridAdapter } from '@/app/GerAdv_TS/Atividades/Adapter/AtividadesGridAdapter';
import AtividadesGridContainer from '@/app/GerAdv_TS/Atividades/Components/AtividadesGridContainer';
const AtividadesPage: React.FC = () => {
  const AtividadesGrid = new AtividadesGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Atividades' />
    <AtividadesGridContainer grid={AtividadesGrid} />
  </PageLayout>
);
};
export default AtividadesPage;