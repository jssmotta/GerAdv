//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { EMPClassRiscosEmpty } from '../../../Models/EMPClassRiscos';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IEMPClassRiscos } from '../../Interfaces/interface.EMPClassRiscos';
import { EMPClassRiscosService } from '../../Services/EMPClassRiscos.service';
import { EMPClassRiscosApi } from '../../Apis/ApiEMPClassRiscos';
import { EMPClassRiscosGridMobileComponent } from '../GridsMobile/EMPClassRiscos';
import { EMPClassRiscosGridDesktopComponent } from '../GridsDesktop/EMPClassRiscos';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterEMPClassRiscos } from '../../Filters/EMPClassRiscos';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import EMPClassRiscosWindow from './EMPClassRiscosWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useEMPClassRiscosList } from '../../Hooks/hookEMPClassRiscos';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const EMPClassRiscosGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const empclassriscosService = useMemo(() => {
    return new EMPClassRiscosService(
    new EMPClassRiscosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: empclassriscos, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useEMPClassRiscosList(empclassriscosService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedEMPClassRiscos, setSelectedEMPClassRiscos] = useState<IEMPClassRiscos>(EMPClassRiscosEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterEMPClassRiscos | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterEMPClassRiscos | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterEMPClassRiscos);
};
// Handlers para o grid
const handleRowClick = (empclassriscos: IEMPClassRiscos) => {
  setSelectedEMPClassRiscos(empclassriscos);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedEMPClassRiscos(EMPClassRiscosEmpty());
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
  const empclassriscos = e.dataItem;
  setDeleteId(empclassriscos.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await empclassriscosService.deleteEMPClassRiscos(deleteId);
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
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
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
    <EMPClassRiscosGridMobileComponent
    data={empclassriscos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <EMPClassRiscosGridDesktopComponent
    data={empclassriscos}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <EMPClassRiscosWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedEMPClassRiscos={selectedEMPClassRiscos}
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
export default EMPClassRiscosGrid;