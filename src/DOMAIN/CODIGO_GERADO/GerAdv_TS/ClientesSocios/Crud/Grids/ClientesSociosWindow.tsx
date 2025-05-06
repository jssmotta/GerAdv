import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ClientesSociosInc from "../Inc/ClientesSocios";
import { IClientesSocios } from "../../Interfaces/interface.ClientesSocios";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ClientesSociosEmpty } from "@/app/GerAdv_TS/Models/ClientesSocios";
import { useWindow } from "@/app/hooks/useWindows";

interface ClientesSociosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedClientesSocios?: IClientesSocios;
    onSuccess: () => void;
    onError: () => void;
}

const ClientesSociosWindow: React.FC<ClientesSociosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedClientesSocios,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/clientessocios/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedClientesSocios?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedClientesSocios]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedClientesSocios?.id ?? 0).toString()}
                >
                    <ClientesSociosInc
                        id={selectedClientesSocios?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowClientesSocios: React.FC<ClientesSociosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ClientesSociosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedClientesSocios={ClientesSociosEmpty()}>
        </ClientesSociosWindow>
    )
};

export default ClientesSociosWindow;