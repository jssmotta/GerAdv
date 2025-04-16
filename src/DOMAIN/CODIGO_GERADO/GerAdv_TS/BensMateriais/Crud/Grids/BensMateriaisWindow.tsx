import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import BensMateriaisInc from "../Inc/BensMateriais";
import { IBensMateriais } from "../../Interfaces/interface.BensMateriais";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { BensMateriaisEmpty } from "@/app/GerAdv_TS/Models/BensMateriais";
import { useWindow } from "@/app/hooks/useWindows";

interface BensMateriaisWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedBensMateriais?: IBensMateriais;
    onSuccess: () => void;
    onError: () => void;
}

const BensMateriaisWindow: React.FC<BensMateriaisWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedBensMateriais,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/bensmateriais/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedBensMateriais?.id}`);
        }

    }, [isMobile, router, selectedBensMateriais]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={641}
                    newWidth={1440}
                    id={(selectedBensMateriais?.id ?? 0).toString()}
                >
                    <BensMateriaisInc
                        id={selectedBensMateriais?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowBensMateriais: React.FC<BensMateriaisWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <BensMateriaisWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedBensMateriais={BensMateriaisEmpty()}>
        </BensMateriaisWindow>
    )
};

export default BensMateriaisWindow;