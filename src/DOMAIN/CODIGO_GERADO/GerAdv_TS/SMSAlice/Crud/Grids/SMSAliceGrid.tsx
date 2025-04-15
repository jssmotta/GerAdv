//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { SMSAliceEmpty } from "../../../Models/SMSAlice";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import SMSAliceInc from "../Inc/SMSAlice";
import { ISMSAlice } from "../../Interfaces/interface.SMSAlice";
import { SMSAliceService } from "../../Services/SMSAlice.service";
import { SMSAliceApi } from "../../Apis/ApiSMSAlice";
import { SMSAliceGridMobileComponent } from "../GridsMobile/SMSAlice";
import { SMSAliceGridDesktopComponent } from "../GridsDesktop/SMSAlice";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterSMSAlice } from "../../Filters/SMSAlice";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import SMSAliceWindow from "./SMSAliceWindow";

const SMSAliceGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [smsalice, setSMSAlice] = useState<ISMSAlice[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedSMSAlice, setSelectedSMSAlice] = useState<ISMSAlice>(SMSAliceEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new SMSAliceApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterSMSAlice | undefined | null>(null);

    const smsaliceService = useMemo(() => {
      return new SMSAliceService(
          new SMSAliceApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchSMSAlice = async (filtro?: FilterSMSAlice | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await smsaliceService.getList(filtro ?? {} as FilterSMSAlice);
        setSMSAlice(data);
      }
      else {
        const data = await smsaliceService.getAll(filtro ?? {} as FilterSMSAlice);
        setSMSAlice(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchSMSAlice(currFilter);
    }, [showInc]);
  
    const handleRowClick = (smsalice: ISMSAlice) => {
      if (isMobile) {
        router.push(`/pages/smsalice/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${smsalice.id}`);
      } else {
        setSelectedSMSAlice(smsalice);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/smsalice/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedSMSAlice(SMSAliceEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchSMSAlice(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const smsalice = e.dataItem;		
        setDeleteId(smsalice.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchSMSAlice(currFilter);
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
           <SMSAliceGridMobileComponent data={smsalice} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <SMSAliceGridDesktopComponent data={smsalice} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <SMSAliceWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedSMSAlice={selectedSMSAlice}>       
        </SMSAliceWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default SMSAliceGrid;