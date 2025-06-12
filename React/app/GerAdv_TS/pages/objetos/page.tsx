'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ObjetosGridAdapter } from '@/app/GerAdv_TS/Objetos/Adapter/ObjetosGridAdapter';
import ObjetosGridContainer from '@/app/GerAdv_TS/Objetos/Components/ObjetosGridContainer';
const ObjetosPage: React.FC = () => {
  const ObjetosGrid = new ObjetosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Objetos' />
    <ObjetosGridContainer grid={ObjetosGrid} />
  </PageLayout>
);
};
export default ObjetosPage;