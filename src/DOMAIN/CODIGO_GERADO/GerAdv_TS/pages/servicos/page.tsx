'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ServicosGridAdapter } from '@/app/GerAdv_TS/Servicos/Adapter/ServicosGridAdapter';
import ServicosGridContainer from '@/app/GerAdv_TS/Servicos/Components/ServicosGridContainer';
const ServicosPage: React.FC = () => {
  const ServicosGrid = new ServicosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Serviços' />
    <ServicosGridContainer grid={ServicosGrid} />
  </PageLayout>
);
};
export default ServicosPage;