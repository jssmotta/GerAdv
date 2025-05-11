import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import OutrasPartesClienteInc from "../Inc/OutrasPartesCliente";
import { IOutrasPartesCliente } from "../../Interfaces/interface.OutrasPartesCliente";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OutrasPartesClienteEmpty } from "@/app/GerAdv_TS/Models/OutrasPartesCliente";
import { useWindow } from "@/app/hooks/useWindows";

interface OutrasPartesClienteWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOutrasPartesCliente?: IOutrasPartesCliente;
    onSuccess: () => void;
    onError: () => void;
}

const OutrasPartesClienteWindow: React.FC<OutrasPartesClienteWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOutrasPartesCliente,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/outraspartescliente/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOutrasPartesCliente?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedOutrasPartesCliente]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={749}
                    newWidth={1440}
                    id={(selectedOutrasPartesCliente?.id ?? 0).toString()}
                >
                    <OutrasPartesClienteInc
                        id={selectedOutrasPartesCliente?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOutrasPartesCliente: React.FC<OutrasPartesClienteWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OutrasPartesClienteWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOutrasPartesCliente={OutrasPartesClienteEmpty()}>
        </OutrasPartesClienteWindow>
    )
};

export default OutrasPartesClienteWindow;