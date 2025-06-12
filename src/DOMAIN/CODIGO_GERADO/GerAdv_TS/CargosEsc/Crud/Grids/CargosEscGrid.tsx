//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { CargosEscEmpty } from '../../../Models/CargosEsc';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ICargosEsc } from '../../Interfaces/interface.CargosEsc';
import { CargosEscService } from '../../Services/CargosEsc.service';
import { CargosEscApi } from '../../Apis/ApiCargosEsc';
import { CargosEscGridMobileComponent } from '../GridsMobile/CargosEsc';
import { CargosEscGridDesktopComponent } from '../GridsDesktop/CargosEsc';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterCargosEsc } from '../../Filters/CargosEsc';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import CargosEscWindow from './CargosEscWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useCargosEscList } from '../../Hooks/hookCargosEsc';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const CargosEscGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const cargosescService = useMemo(() => {
    return new CargosEscService(
    new CargosEscApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: cargosesc, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useCargosEscList(cargosescService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedCargosEsc, setSelectedCargosEsc] = useState<ICargosEsc>(CargosEscEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterCargosEsc | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterCargosEsc | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterCargosEsc);
};
// Handlers para o grid
const handleRowClick = (cargosesc: ICargosEsc) => {
  setSelectedCargosEsc(cargosesc);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedCargosEsc(CargosEscEmpty());
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
  const cargosesc = e.dataItem;
  setDeleteId(cargosesc.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await cargosescService.deleteCargosEsc(deleteId);
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
    <CargosEscGridMobileComponent
    data={cargosesc}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <CargosEscGridDesktopComponent
    data={cargosesc}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <CargosEscWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedCargosEsc={selectedCargosEsc}
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
export default CargosEscGrid;