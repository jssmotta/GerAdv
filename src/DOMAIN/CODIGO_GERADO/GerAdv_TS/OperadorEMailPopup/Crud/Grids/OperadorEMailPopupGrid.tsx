//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { OperadorEMailPopupEmpty } from '../../../Models/OperadorEMailPopup';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IOperadorEMailPopup } from '../../Interfaces/interface.OperadorEMailPopup';
import { OperadorEMailPopupService } from '../../Services/OperadorEMailPopup.service';
import { OperadorEMailPopupApi } from '../../Apis/ApiOperadorEMailPopup';
import { OperadorEMailPopupGridMobileComponent } from '../GridsMobile/OperadorEMailPopup';
import { OperadorEMailPopupGridDesktopComponent } from '../GridsDesktop/OperadorEMailPopup';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterOperadorEMailPopup } from '../../Filters/OperadorEMailPopup';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import OperadorEMailPopupWindow from './OperadorEMailPopupWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useOperadorEMailPopupList } from '../../Hooks/hookOperadorEMailPopup';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const OperadorEMailPopupGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const operadoremailpopupService = useMemo(() => {
    return new OperadorEMailPopupService(
    new OperadorEMailPopupApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: operadoremailpopup, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useOperadorEMailPopupList(operadoremailpopupService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedOperadorEMailPopup, setSelectedOperadorEMailPopup] = useState<IOperadorEMailPopup>(OperadorEMailPopupEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterOperadorEMailPopup | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterOperadorEMailPopup | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterOperadorEMailPopup);
};
// Handlers para o grid
const handleRowClick = (operadoremailpopup: IOperadorEMailPopup) => {
  setSelectedOperadorEMailPopup(operadoremailpopup);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedOperadorEMailPopup(OperadorEMailPopupEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const operadoremailpopup = e.dataItem;
  setDeleteId(operadoremailpopup.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await operadoremailpopupService.deleteOperadorEMailPopup(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <OperadorEMailPopupGridMobileComponent
    data={operadoremailpopup}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <OperadorEMailPopupGridDesktopComponent
    data={operadoremailpopup}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <OperadorEMailPopupWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedOperadorEMailPopup={selectedOperadorEMailPopup}
    />
    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default OperadorEMailPopupGrid;