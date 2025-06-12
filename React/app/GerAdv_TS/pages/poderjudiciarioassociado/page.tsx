'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { PoderJudiciarioAssociadoGridAdapter } from '@/app/GerAdv_TS/PoderJudiciarioAssociado/Adapter/PoderJudiciarioAssociadoGridAdapter';
import PoderJudiciarioAssociadoGridContainer from '@/app/GerAdv_TS/PoderJudiciarioAssociado/Components/PoderJudiciarioAssociadoGridContainer';
const PoderJudiciarioAssociadoPage: React.FC = () => {
  const PoderJudiciarioAssociadoGrid = new PoderJudiciarioAssociadoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Poder Judiciario Associado' />
    <PoderJudiciarioAssociadoGridContainer grid={PoderJudiciarioAssociadoGrid} />
  </PageLayout>
);
};
export default PoderJudiciarioAssociadoPage;