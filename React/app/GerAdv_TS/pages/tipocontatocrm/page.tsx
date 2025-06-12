'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { TipoContatoCRMGridAdapter } from '@/app/GerAdv_TS/TipoContatoCRM/Adapter/TipoContatoCRMGridAdapter';
import TipoContatoCRMGridContainer from '@/app/GerAdv_TS/TipoContatoCRM/Components/TipoContatoCRMGridContainer';
const TipoContatoCRMPage: React.FC = () => {
  const TipoContatoCRMGrid = new TipoContatoCRMGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Tipo Contato C R M' />
    <TipoContatoCRMGridContainer grid={TipoContatoCRMGrid} />
  </PageLayout>
);
};
export default TipoContatoCRMPage;