'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import DocsRecebidosItensInc from '../Crud/Inc/DocsRecebidosItens';
import { getParamFromUrl } from '@/app/tools/helpers';
interface DocsRecebidosItensIncContainerProps {
  id: number;
  navigator: INavigator;
}
const DocsRecebidosItensIncContainer: React.FC<DocsRecebidosItensIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <DocsRecebidosItensInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default DocsRecebidosItensIncContainer;