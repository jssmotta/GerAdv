// ProCDAGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ProCDAGridAdapter } from '@/app/GerAdv_TS/ProCDA/Adapter/ProCDAGridAdapter';
// Mock ProCDAGrid component
jest.mock('@/app/GerAdv_TS/ProCDA/Crud/Grids/ProCDAGrid', () => () => <div data-testid='procda-grid-mock' />);
describe('ProCDAGridAdapter', () => {
  it('should render ProCDAGrid component', () => {
    const adapter = new ProCDAGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('procda-grid-mock')).toBeInTheDocument();
  });
});