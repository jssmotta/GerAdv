//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { CargosEscClassEmpty } from '../../../Models/CargosEscClass';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ICargosEscClass } from '../../Interfaces/interface.CargosEscClass';
import { CargosEscClassService } from '../../Services/CargosEscClass.service';
import { CargosEscClassApi } from '../../Apis/ApiCargosEscClass';
import { CargosEscClassGridMobileComponent } from '../GridsMobile/CargosEscClass';
import { CargosEscClassGridDesktopComponent } from '../GridsDesktop/CargosEscClass';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterCargosEscClass } from '../../Filters/CargosEscClass';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import CargosEscClassWindow from './CargosEscClassWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useCargosEscClassList } from '../../Hooks/hookCargosEscClass';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const CargosEscClassGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const cargosescclassService = useMemo(() => {
    return new CargosEscClassService(
    new CargosEscClassApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: cargosescclass, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useCargosEscClassList(cargosescclassService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedCargosEscClass, setSelectedCargosEscClass] = useState<ICargosEscClass>(CargosEscClassEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterCargosEscClass | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterCargosEscClass | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterCargosEscClass);
};
// Handlers para o grid
const handleRowClick = (cargosescclass: ICargosEscClass) => {
  setSelectedCargosEscClass(cargosescclass);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedCargosEscClass(CargosEscClassEmpty());
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
  const cargosescclass = e.dataItem;
  setDeleteId(cargosescclass.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await cargosescclassService.deleteCargosEscClass(deleteId);
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
    <CargosEscClassGridMobileComponent
    data={cargosescclass}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <CargosEscClassGridDesktopComponent
    data={cargosescclass}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <CargosEscClassWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedCargosEscClass={selectedCargosEscClass}
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
export default CargosEscClassGrid;