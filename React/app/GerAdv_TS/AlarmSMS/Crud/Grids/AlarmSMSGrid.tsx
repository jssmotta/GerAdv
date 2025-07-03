//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { AlarmSMSEmpty } from '../../../Models/AlarmSMS';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IAlarmSMS } from '../../Interfaces/interface.AlarmSMS';
import { AlarmSMSService } from '../../Services/AlarmSMS.service';
import { AlarmSMSApi } from '../../Apis/ApiAlarmSMS';
import { AlarmSMSGridMobileComponent } from '../GridsMobile/AlarmSMS';
import { AlarmSMSGridDesktopComponent } from '../GridsDesktop/AlarmSMS';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterAlarmSMS } from '../../Filters/AlarmSMS';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import AlarmSMSWindow from './AlarmSMSWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useAlarmSMSList } from '../../Hooks/hookAlarmSMS';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const AlarmSMSGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const alarmsmsService = useMemo(() => {
    return new AlarmSMSService(
    new AlarmSMSApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: alarmsms, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useAlarmSMSList(alarmsmsService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedAlarmSMS, setSelectedAlarmSMS] = useState<IAlarmSMS>(AlarmSMSEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterAlarmSMS | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterAlarmSMS | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterAlarmSMS);
};
// Handlers para o grid
const handleRowClick = (alarmsms: IAlarmSMS) => {
  setSelectedAlarmSMS(alarmsms);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedAlarmSMS(AlarmSMSEmpty());
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
  const alarmsms = e.dataItem;
  setDeleteId(alarmsms.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await alarmsmsService.deleteAlarmSMS(deleteId);
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
    <AlarmSMSGridMobileComponent
    data={alarmsms}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <AlarmSMSGridDesktopComponent
    data={alarmsms}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <AlarmSMSWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedAlarmSMS={selectedAlarmSMS}
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
export default AlarmSMSGrid;