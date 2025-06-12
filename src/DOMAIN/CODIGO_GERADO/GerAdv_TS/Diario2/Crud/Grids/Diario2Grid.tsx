//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { Diario2Empty } from '../../../Models/Diario2';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IDiario2 } from '../../Interfaces/interface.Diario2';
import { Diario2Service } from '../../Services/Diario2.service';
import { Diario2Api } from '../../Apis/ApiDiario2';
import { Diario2GridMobileComponent } from '../GridsMobile/Diario2';
import { Diario2GridDesktopComponent } from '../GridsDesktop/Diario2';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterDiario2 } from '../../Filters/Diario2';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import Diario2Window from './Diario2Window';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useDiario2List } from '../../Hooks/hookDiario2';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const Diario2Grid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const diario2Service = useMemo(() => {
    return new Diario2Service(
    new Diario2Api(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: diario2, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useDiario2List(diario2Service);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedDiario2, setSelectedDiario2] = useState<IDiario2>(Diario2Empty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterDiario2 | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterDiario2 | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterDiario2);
};
// Handlers para o grid
const handleRowClick = (diario2: IDiario2) => {
  setSelectedDiario2(diario2);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedDiario2(Diario2Empty());
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
  const diario2 = e.dataItem;
  setDeleteId(diario2.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await diario2Service.deleteDiario2(deleteId);
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
    <Diario2GridMobileComponent
    data={diario2}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <Diario2GridDesktopComponent
    data={diario2}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <Diario2Window
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedDiario2={selectedDiario2}
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
export default Diario2Grid;