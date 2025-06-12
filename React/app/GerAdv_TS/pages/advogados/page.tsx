'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AdvogadosGridAdapter } from '@/app/GerAdv_TS/Advogados/Adapter/AdvogadosGridAdapter';
import AdvogadosGridContainer from '@/app/GerAdv_TS/Advogados/Components/AdvogadosGridContainer';
const AdvogadosPage: React.FC = () => {
  const AdvogadosGrid = new AdvogadosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Advogados' />
    <AdvogadosGridContainer grid={AdvogadosGrid} />
  </PageLayout>
);
};
export default AdvogadosPage;