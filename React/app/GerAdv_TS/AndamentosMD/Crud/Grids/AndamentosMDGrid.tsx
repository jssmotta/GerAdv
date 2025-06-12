//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AndamentosMDEmpty } from '../../../Models/AndamentosMD';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAndamentosMD } from '../../Interfaces/interface.AndamentosMD';
import { AndamentosMDService } from '../../Services/AndamentosMD.service';
import { AndamentosMDApi } from '../../Apis/ApiAndamentosMD';
import { AndamentosMDGridMobileComponent } from '../GridsMobile/AndamentosMD';
import { AndamentosMDGridDesktopComponent } from '../GridsDesktop/AndamentosMD';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAndamentosMD } from '../../Filters/AndamentosMD';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AndamentosMDWindow from './AndamentosMDWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAndamentosMDList } from '../../Hooks/hookAndamentosMD';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const AndamentosMDGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const andamentosmdService = useMemo(() => {
    return new AndamentosMDService(
    new AndamentosMDApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: andamentosmd, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAndamentosMDList(andamentosmdService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAndamentosMD, setSelectedAndamentosMD] = useState<IAndamentosMD>(AndamentosMDEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAndamentosMD | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAndamentosMD | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAndamentosMD);
};
// Handlers para o grid
const handleRowClick = (andamentosmd: IAndamentosMD) => {
  setSelectedAndamentosMD(andamentosmd);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAndamentosMD(AndamentosMDEmpty());
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
  const andamentosmd = e.dataItem;
  setDeleteId(andamentosmd.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await andamentosmdService.deleteAndamentosMD(deleteId);
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
    <AndamentosMDGridMobileComponent
    data={andamentosmd}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AndamentosMDGridDesktopComponent
    data={andamentosmd}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AndamentosMDWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAndamentosMD={selectedAndamentosMD}
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
export default AndamentosMDGrid;