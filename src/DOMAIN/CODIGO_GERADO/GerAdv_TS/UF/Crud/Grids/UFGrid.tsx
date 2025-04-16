//CrudGrid.tsx.txt
"use client";
import { EditWindow } from "@/app/components/EditWindow"; 
import { AppGridToolbar } from "@/app/components/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { UFEmpty } from "../../../Models/UF";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import UFInc from "../Inc/UF";
import { IUF } from "../../Interfaces/interface.UF";
import { UFService } from "../../Services/UF.service";
import { UFApi } from "../../Apis/ApiUF";
import { UFGridMobileComponent } from "../GridsMobile/UF";
import { UFGridDesktopComponent } from "../GridsDesktop/UF";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterUF } from "../../Filters/UF";
import { ConfirmationModal } from "@/app/components/ConfirmationModal";
import UFWindow from "./UFWindow";

const UFGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [uf, setUF] = useState<IUF[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedUF, setSelectedUF] = useState<IUF>(UFEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterUF | undefined | null>(null);

    const ufService = useMemo(() => {
      return new UFService(
          new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchUF = async (filtro?: FilterUF | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await ufService.getList(filtro ?? {} as FilterUF);
        setUF(data);
      }
      else {
        const data = await ufService.getAll(filtro ?? {} as FilterUF);
        setUF(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchUF(currFilter);
    }, [showInc]);
  
    const handleRowClick = (uf: IUF) => {
      if (isMobile) {
        router.push(`/pages/uf/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${uf.id}`);
      } else {
        setSelectedUF(uf);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/uf/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedUF(UFEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchUF(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const uf = e.dataItem;		
        setDeleteId(uf.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchUF(currFilter);
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
           <UFGridMobileComponent data={uf} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> :
           <UFGridDesktopComponent data={uf} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} /> }       
     
        <UFWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedUF={selectedUF}>       
        </UFWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default UFGrid;