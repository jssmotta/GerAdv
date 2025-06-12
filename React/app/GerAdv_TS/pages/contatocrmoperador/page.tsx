'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ContatoCRMOperadorGridAdapter } from '@/app/GerAdv_TS/ContatoCRMOperador/Adapter/ContatoCRMOperadorGridAdapter';
import ContatoCRMOperadorGridContainer from '@/app/GerAdv_TS/ContatoCRMOperador/Components/ContatoCRMOperadorGridContainer';
const ContatoCRMOperadorPage: React.FC = () => {
  const ContatoCRMOperadorGrid = new ContatoCRMOperadorGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Contato C R M Operador' />
    <ContatoCRMOperadorGridContainer grid={ContatoCRMOperadorGrid} />
  </PageLayout>
);
};
export default ContatoCRMOperadorPage;