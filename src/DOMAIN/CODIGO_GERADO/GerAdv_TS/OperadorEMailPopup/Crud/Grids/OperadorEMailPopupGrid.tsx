//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OperadorEMailPopupEmpty } from "../../../Models/OperadorEMailPopup";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IOperadorEMailPopup } from "../../Interfaces/interface.OperadorEMailPopup";
import { OperadorEMailPopupService } from "../../Services/OperadorEMailPopup.service";
import { OperadorEMailPopupApi } from "../../Apis/ApiOperadorEMailPopup";
import { OperadorEMailPopupGridMobileComponent } from "../GridsMobile/OperadorEMailPopup";
import { OperadorEMailPopupGridDesktopComponent } from "../GridsDesktop/OperadorEMailPopup";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOperadorEMailPopup } from "../../Filters/OperadorEMailPopup";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import OperadorEMailPopupWindow from "./OperadorEMailPopupWindow";

const OperadorEMailPopupGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [operadoremailpopup, setOperadorEMailPopup] = useState<IOperadorEMailPopup[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOperadorEMailPopup, setSelectedOperadorEMailPopup] = useState<IOperadorEMailPopup>(OperadorEMailPopupEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OperadorEMailPopupApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOperadorEMailPopup | undefined | null>(null);

    const operadoremailpopupService = useMemo(() => {
      return new OperadorEMailPopupService(
          new OperadorEMailPopupApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOperadorEMailPopup = async (filtro?: FilterOperadorEMailPopup | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await operadoremailpopupService.getList(filtro ?? {} as FilterOperadorEMailPopup);
        setOperadorEMailPopup(data);
      }
      else {
        const data = await operadoremailpopupService.getAll(filtro ?? {} as FilterOperadorEMailPopup);
        setOperadorEMailPopup(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOperadorEMailPopup(currFilter);
    }, [showInc]);
  
    const handleRowClick = (operadoremailpopup: IOperadorEMailPopup) => {
      if (isMobile) {
        router.push(`/pages/operadoremailpopup/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${operadoremailpopup.id}`);
      } else {
        setSelectedOperadorEMailPopup(operadoremailpopup);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/operadoremailpopup/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOperadorEMailPopup(OperadorEMailPopupEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOperadorEMailPopup(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const operadoremailpopup = e.dataItem;		
        setDeleteId(operadoremailpopup.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOperadorEMailPopup(currFilter);
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
           <OperadorEMailPopupGridMobileComponent data={operadoremailpopup} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <OperadorEMailPopupGridDesktopComponent data={operadoremailpopup} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <OperadorEMailPopupWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOperadorEMailPopup={selectedOperadorEMailPopup}>       
        </OperadorEMailPopupWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OperadorEMailPopupGrid;