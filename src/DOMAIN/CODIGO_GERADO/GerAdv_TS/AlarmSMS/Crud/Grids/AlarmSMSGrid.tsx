//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { AlarmSMSEmpty } from "../../../Models/AlarmSMS";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import AlarmSMSInc from "../Inc/AlarmSMS";
import { IAlarmSMS } from "../../Interfaces/interface.AlarmSMS";
import { AlarmSMSService } from "../../Services/AlarmSMS.service";
import { AlarmSMSApi } from "../../Apis/ApiAlarmSMS";
import { AlarmSMSGridMobileComponent } from "../GridsMobile/AlarmSMS";
import { AlarmSMSGridDesktopComponent } from "../GridsDesktop/AlarmSMS";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterAlarmSMS } from "../../Filters/AlarmSMS";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import AlarmSMSWindow from "./AlarmSMSWindow";

const AlarmSMSGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [alarmsms, setAlarmSMS] = useState<IAlarmSMS[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedAlarmSMS, setSelectedAlarmSMS] = useState<IAlarmSMS>(AlarmSMSEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new AlarmSMSApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterAlarmSMS | undefined | null>(null);

    const alarmsmsService = useMemo(() => {
      return new AlarmSMSService(
          new AlarmSMSApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchAlarmSMS = async (filtro?: FilterAlarmSMS | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await alarmsmsService.getList(filtro ?? {} as FilterAlarmSMS);
        setAlarmSMS(data);
      }
      else {
        const data = await alarmsmsService.getAll(filtro ?? {} as FilterAlarmSMS);
        setAlarmSMS(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchAlarmSMS(currFilter);
    }, [showInc]);
  
    const handleRowClick = (alarmsms: IAlarmSMS) => {
      if (isMobile) {
        router.push(`/pages/alarmsms/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${alarmsms.id}`);
      } else {
        setSelectedAlarmSMS(alarmsms);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/alarmsms/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedAlarmSMS(AlarmSMSEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchAlarmSMS(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const alarmsms = e.dataItem;		
        setDeleteId(alarmsms.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchAlarmSMS(currFilter);
            } catch {
            // falta uma mensagem de erro
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

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <AlarmSMSGridMobileComponent data={alarmsms} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <AlarmSMSGridDesktopComponent data={alarmsms} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <AlarmSMSWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedAlarmSMS={selectedAlarmSMS}>       
        </AlarmSMSWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default AlarmSMSGrid;