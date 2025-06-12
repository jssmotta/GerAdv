'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ContaCorrenteGridAdapter } from '@/app/GerAdv_TS/ContaCorrente/Adapter/ContaCorrenteGridAdapter';
import ContaCorrenteGridContainer from '@/app/GerAdv_TS/ContaCorrente/Components/ContaCorrenteGridContainer';
const ContaCorrentePage: React.FC = () => {
  const ContaCorrenteGrid = new ContaCorrenteGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Conta Corrente' />
    <ContaCorrenteGridContainer grid={ContaCorrenteGrid} />
  </PageLayout>
);
};
export default ContaCorrentePage;