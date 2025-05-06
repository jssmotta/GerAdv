//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { OponentesEmpty } from "../../../Models/Oponentes";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IOponentes } from "../../Interfaces/interface.Oponentes";
import { OponentesService } from "../../Services/Oponentes.service";
import { OponentesApi } from "../../Apis/ApiOponentes";
import { OponentesGridMobileComponent } from "../GridsMobile/Oponentes";
import { OponentesGridDesktopComponent } from "../GridsDesktop/Oponentes";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterOponentes } from "../../Filters/Oponentes";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import OponentesWindow from "./OponentesWindow";

const OponentesGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [oponentes, setOponentes] = useState<IOponentes[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedOponentes, setSelectedOponentes] = useState<IOponentes>(OponentesEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterOponentes | undefined | null>(null);

    const oponentesService = useMemo(() => {
      return new OponentesService(
          new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchOponentes = async (filtro?: FilterOponentes | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await oponentesService.getList(filtro ?? {} as FilterOponentes);
        setOponentes(data);
      }
      else {
        const data = await oponentesService.getAll(filtro ?? {} as FilterOponentes);
        setOponentes(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchOponentes(currFilter);
    }, [showInc]);
  
    const handleRowClick = (oponentes: IOponentes) => {
      if (isMobile) {
        router.push(`/pages/oponentes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${oponentes.id}`);
      } else {
        setSelectedOponentes(oponentes);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/oponentes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedOponentes(OponentesEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchOponentes(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const oponentes = e.dataItem;		
        setDeleteId(oponentes.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchOponentes(currFilter);
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
           <OponentesGridMobileComponent data={oponentes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <OponentesGridDesktopComponent data={oponentes} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <OponentesWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedOponentes={selectedOponentes}>       
        </OponentesWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default OponentesGrid;