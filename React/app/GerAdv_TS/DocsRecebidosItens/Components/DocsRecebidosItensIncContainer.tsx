'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import DocsRecebidosItensInc from '../Crud/Inc/DocsRecebidosItens';
import { getParamFromUrl } from '@/app/tools/helpers';
interface DocsRecebidosItensIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const DocsRecebidosItensIncContainer: React.FC<DocsRecebidosItensIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <DocsRecebidosItensInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default DocsRecebidosItensIncContainer;