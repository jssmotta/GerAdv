//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { GruposEmpresasCliEmpty } from "../../../Models/GruposEmpresasCli";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IGruposEmpresasCli } from "../../Interfaces/interface.GruposEmpresasCli";
import { GruposEmpresasCliService } from "../../Services/GruposEmpresasCli.service";
import { GruposEmpresasCliApi } from "../../Apis/ApiGruposEmpresasCli";
import { GruposEmpresasCliGridMobileComponent } from "../GridsMobile/GruposEmpresasCli";
import { GruposEmpresasCliGridDesktopComponent } from "../GridsDesktop/GruposEmpresasCli";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterGruposEmpresasCli } from "../../Filters/GruposEmpresasCli";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import GruposEmpresasCliWindow from "./GruposEmpresasCliWindow";

const GruposEmpresasCliGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [gruposempresascli, setGruposEmpresasCli] = useState<IGruposEmpresasCli[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedGruposEmpresasCli, setSelectedGruposEmpresasCli] = useState<IGruposEmpresasCli>(GruposEmpresasCliEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new GruposEmpresasCliApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterGruposEmpresasCli | undefined | null>(null);

    const gruposempresascliService = useMemo(() => {
      return new GruposEmpresasCliService(
          new GruposEmpresasCliApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchGruposEmpresasCli = async (filtro?: FilterGruposEmpresasCli | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await gruposempresascliService.getAll(filtro ?? {} as FilterGruposEmpresasCli);
        setGruposEmpresasCli(data);
      }
      else {
        const data = await gruposempresascliService.getAll(filtro ?? {} as FilterGruposEmpresasCli);
        setGruposEmpresasCli(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchGruposEmpresasCli(currFilter);
    }, [showInc]);
  
    const handleRowClick = (gruposempresascli: IGruposEmpresasCli) => {
      if (isMobile) {
        router.push(`/pages/gruposempresascli/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${gruposempresascli.id}`);
      } else {
        setSelectedGruposEmpresasCli(gruposempresascli);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/gruposempresascli/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedGruposEmpresasCli(GruposEmpresasCliEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchGruposEmpresasCli(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const gruposempresascli = e.dataItem;		
        setDeleteId(gruposempresascli.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchGruposEmpresasCli(currFilter);
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
            
        {isMobile ?
           <GruposEmpresasCliGridMobileComponent data={gruposempresascli} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <GruposEmpresasCliGridDesktopComponent data={gruposempresascli} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <GruposEmpresasCliWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedGruposEmpresasCli={selectedGruposEmpresasCli}>       
        </GruposEmpresasCliWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default GruposEmpresasCliGrid;