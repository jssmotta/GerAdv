// PosicaoOutrasPartesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { PosicaoOutrasPartesGridAdapter } from '@/app/GerAdv_TS/PosicaoOutrasPartes/Adapter/PosicaoOutrasPartesGridAdapter';
// Mock PosicaoOutrasPartesGrid component
jest.mock('@/app/GerAdv_TS/PosicaoOutrasPartes/Crud/Grids/PosicaoOutrasPartesGrid', () => () => <div data-testid='posicaooutraspartes-grid-mock' />);
describe('PosicaoOutrasPartesGridAdapter', () => {
  it('should render PosicaoOutrasPartesGrid component', () => {
    const adapter = new PosicaoOutrasPartesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('posicaooutraspartes-grid-mock')).toBeInTheDocument();
  });
});