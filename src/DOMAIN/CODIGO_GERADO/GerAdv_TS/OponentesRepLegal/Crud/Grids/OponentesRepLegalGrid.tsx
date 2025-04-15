//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OponentesRepLegalEmpty } from "../../../Models/OponentesRepLegal";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import OponentesRepLegalInc from "../Inc/OponentesRepLegal";
import { IOponentesRepLegal } from "../../Interfaces/interface.OponentesRepLegal";
import { OponentesRepLegalService } from "../../Services/OponentesRepLegal.service";
import { OponentesRepLegalApi } from "../../Apis/ApiOponentesRepLegal";
import { OponentesRepLegalGridMobileComponent } from "../GridsMobile/OponentesRepLegal";
import { OponentesRepLegalGridDesktopComponent } from "../GridsDesktop/OponentesRepLegal";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOponentesRepLegal } from "../../Filters/OponentesRepLegal";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import OponentesRepLegalWindow from "./OponentesRepLegalWindow";

const OponentesRepLegalGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [oponentesreplegal, setOponentesRepLegal] = useState<IOponentesRepLegal[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOponentesRepLegal, setSelectedOponentesRepLegal] = useState<IOponentesRepLegal>(OponentesRepLegalEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OponentesRepLegalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOponentesRepLegal | undefined | null>(null);

    const oponentesreplegalService = useMemo(() => {
      return new OponentesRepLegalService(
          new OponentesRepLegalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOponentesRepLegal = async (filtro?: FilterOponentesRepLegal | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await oponentesreplegalService.getList(filtro ?? {} as FilterOponentesRepLegal);
        setOponentesRepLegal(data);
      }
      else {
        const data = await oponentesreplegalService.getAll(filtro ?? {} as FilterOponentesRepLegal);
        setOponentesRepLegal(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOponentesRepLegal(currFilter);
    }, [showInc]);
  
    const handleRowClick = (oponentesreplegal: IOponentesRepLegal) => {
      if (isMobile) {
        router.push(`/pages/oponentesreplegal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${oponentesreplegal.id}`);
      } else {
        setSelectedOponentesRepLegal(oponentesreplegal);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/oponentesreplegal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOponentesRepLegal(OponentesRepLegalEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOponentesRepLegal(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const oponentesreplegal = e.dataItem;		
        setDeleteId(oponentesreplegal.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOponentesRepLegal(currFilter);
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
           <OponentesRepLegalGridMobileComponent data={oponentesreplegal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <OponentesRepLegalGridDesktopComponent data={oponentesreplegal} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <OponentesRepLegalWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOponentesRepLegal={selectedOponentesRepLegal}>       
        </OponentesRepLegalWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OponentesRepLegalGrid;