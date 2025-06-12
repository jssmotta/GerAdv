'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { InstanciaGridAdapter } from '@/app/GerAdv_TS/Instancia/Adapter/InstanciaGridAdapter';
import InstanciaGridContainer from '@/app/GerAdv_TS/Instancia/Components/InstanciaGridContainer';
const InstanciaPage: React.FC = () => {
  const InstanciaGrid = new InstanciaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Instancia' />
    <InstanciaGridContainer grid={InstanciaGrid} />
  </PageLayout>
);
};
export default InstanciaPage;