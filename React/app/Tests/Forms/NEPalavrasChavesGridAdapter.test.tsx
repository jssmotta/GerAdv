// NEPalavrasChavesGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { NEPalavrasChavesGridAdapter } from '@/app/GerAdv_TS/NEPalavrasChaves/Adapter/NEPalavrasChavesGridAdapter';
// Mock NEPalavrasChavesGrid component
jest.mock('@/app/GerAdv_TS/NEPalavrasChaves/Crud/Grids/NEPalavrasChavesGrid', () => () => <div data-testid='nepalavraschaves-grid-mock' />);
describe('NEPalavrasChavesGridAdapter', () => {
  it('should render NEPalavrasChavesGrid component', () => {
    const adapter = new NEPalavrasChavesGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('nepalavraschaves-grid-mock')).toBeInTheDocument();
  });
});